using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Idx.RoundFilterMenu
{
    public partial class FilterMenu : ContentView
    {
		public event EventHandler ItemTapped;

        private bool _isAnimating = false;
        private uint _animationDelay = 300;

        public FilterMenu()
        {
            InitializeComponent();

            InnerButtonClose.IsVisible = false;
            InnerButtonMenu.IsVisible = true;
            HandleMenuCenterClicked();
            HandleCloseClicked();

            HandleOptionsClicked();
        }

        private void HandleOptionsClicked()
        {
            HandleOptionClicked(N, "Plane");
            HandleOptionClicked(NE, "Van");
            HandleOptionClicked(E, "Factory");
            HandleOptionClicked(SE, "Cow");
            HandleOptionClicked(S, "Paintbrush");
            HandleOptionClicked(SW, "Award");
            HandleOptionClicked(W, "Add Person");
            HandleOptionClicked(NW, "Acorn");

        }

        private void HandleOptionClicked(Image image, string value)
        {
            image.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    ItemTapped?.Invoke(this, new SelectedItemChangedEventArgs(value));
                    CloseMenu();
                }),
                NumberOfTapsRequired = 1
            });
        }

        private void HandleCloseClicked()
        {
            InnerButtonClose.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    await CloseMenu();
                }),
                NumberOfTapsRequired = 1
            });

        }

        private async Task CloseMenu()
        {
            if (!_isAnimating)
            {

                _isAnimating = true;

                InnerButtonMenu.IsVisible = true;
                InnerButtonClose.IsVisible = true;
                await HideButtons();

                InnerButtonClose.RotateTo(0, _animationDelay);
                InnerButtonClose.FadeTo(0, _animationDelay);
                InnerButtonMenu.RotateTo(0, _animationDelay);
                InnerButtonMenu.FadeTo(1, _animationDelay);
                await OuterCircle.ScaleTo(1, 1000, Easing.BounceOut);
                InnerButtonClose.IsVisible = false;

                _isAnimating = false;
            }
        }

        private void HandleMenuCenterClicked()
        {
            InnerButtonMenu.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    if (!_isAnimating)
                    {
                        _isAnimating = true;

                        InnerButtonClose.IsVisible = true;
                        InnerButtonMenu.IsVisible = true;

                        InnerButtonMenu.RotateTo(360, _animationDelay);
                        InnerButtonMenu.FadeTo(0, _animationDelay);
                        InnerButtonClose.RotateTo(360, _animationDelay);
                        InnerButtonClose.FadeTo(1, _animationDelay);

                        await OuterCircle.ScaleTo(3.3, 1000, Easing.BounceIn);
                        await ShowButtons();
                        InnerButtonMenu.IsVisible = false;

                        _isAnimating = false;

                    }
                }),
                NumberOfTapsRequired = 1
            });

        }

        private async Task HideButtons()
        {
            var speed = 25U;
            await N.FadeTo(0, speed);
            await NE.FadeTo(0, speed);
            await E.FadeTo(0, speed);
            await SE.FadeTo(0, speed);
            await S.FadeTo(0, speed);
            await SW.FadeTo(0, speed);
            await W.FadeTo(0, speed);
            await NW.FadeTo(0, speed);
        }

        private async Task ShowButtons()
        {
            var speed = 25U;
            await N.FadeTo(1, speed);
            await NE.FadeTo(1, speed);
            await E.FadeTo(1, speed);
            await SE.FadeTo(1, speed);
            await S.FadeTo(1, speed);
            await SW.FadeTo(1, speed);
            await W.FadeTo(1, speed);
            await NW.FadeTo(1, speed);
        }
    }
}
