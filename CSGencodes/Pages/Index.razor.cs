using CSGencodes.Core.Models;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace CSGencodes.Pages
{
    public partial class Index
    {
        private decimal _float = 0.01m;
        private int _pattern = 661;
        private bool isProcessingInput = false;
        private CancellationTokenSource? cancellationTokenSource;
        private async Task StartInputProcessing(ChangeEventArgs e)
        {
            // Cancel any previous input processing
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource.Dispose();
            }

            // Create a new cancellation token source
            cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            try
            {
                // Wait for a brief delay (e.g., 20ms)
                await Task.Delay(250, cancellationToken);

                // Trigger the binding after the delay
                if (!cancellationToken.IsCancellationRequested)
                {
                    Settings.StickerFilter.Searchterm = e.Value?.ToString() ?? string.Empty;
                    StateHasChanged();
                }
            }
            catch (TaskCanceledException)
            {
                // Task was canceled, ignore
            }
        }
        [CascadingParameter]
        public CSGencodesSettings Settings { get; set; } = default!;
        public Weapon? SelectedWeapon { get; set; }

        public List<AppliedSticker> SelectedStickers { get; set; } = [];

        public string CustomName { get; set; } = string.Empty;
        public decimal Float
        {
            get => _float;
            set
            {
                _float = value;

                if (Settings.MinMaxFloats)
                {
                    decimal min_float = SelectedWeapon?.min_wear ?? 0m;
                    decimal max_float = SelectedWeapon?.max_wear ?? 1m;

                    if (value <= min_float)
                    {
                        _float = min_float;
                    }
                    else if (value > max_float)
                    {
                        _float = max_float;
                    }
                }
            }
        }

        public int Pattern
        {
            get => _pattern;
            set
            {
                if (value < 0)
                {
                    _pattern = 0;
                }
                else if (value > 1000)
                {
                    _pattern = 1000;
                }
                else
                {
                    _pattern = value;
                }
            }
        }
        private void OnWeaponClicked(Weapon weapon)
        {
            SelectedWeapon = weapon;

            if (Settings.MinMaxFloats)
            {
                if (Float <= weapon.min_wear)
                {
                    _float = weapon.min_wear;
                }
                else if (Float > weapon.max_wear)
                {
                    _float = weapon.max_wear;
                }
            }
        }

        private void OnStickerClicked(Sticker sticker)
        {
            if (SelectedStickers.Count < 5)
            {
                for (int posId = 0; posId < 5; posId++)
                {
                    var searchSticker = SelectedStickers.FirstOrDefault(x => x.PosId == posId);

                    if (searchSticker is null)
                    {
                        SelectedStickers.Add(new AppliedSticker(sticker, posId));
                        SortSelectedStickers();
                        break;
                    }
                }
            }
        }







        private void RemoveLastSticker()
        {
            SelectedStickers.RemoveAt(SelectedStickers.Count - 1);
        }


        private void SortSelectedStickers()
        {
            SelectedStickers.Sort((x, y) => x.PosId.CompareTo(y.PosId));
        }



        private async Task OnStickerWearingChange(ChangeEventArgs e, AppliedSticker sticker)
        {
            decimal.TryParse(e.Value.ToString(), CultureInfo.InvariantCulture, out decimal newValue);

            sticker.Scratched = newValue;
        }

    }
}