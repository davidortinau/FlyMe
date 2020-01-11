using System;
using Sharpnado.Presentation.Forms.Helpers;
using Sharpnado.Presentation.Forms.ViewModels;
using Xamarin.Forms;

namespace FlyMe.ViewModels
{
    public class AppTabsViewModel : Sharpnado.Presentation.Forms.ViewModels.Bindable
    {
        public AppTabsViewModel()
        {
            BookCommand = new Command(OnBooking);
        }

        private void OnBooking()
        {
            // maybe navigate somewhere
        }

        private int _selectedViewModelIndex;
        private Command bookCommand;

        public Command BookCommand { get => bookCommand; set => SetAndRaise(ref bookCommand, value); }


        //public ViewModelLoader<SillyDudeVmo> SillyDudeLoader { get; }

        //public QuoteVmo Quote { get; private set; }

        //public FilmoVmo Filmo { get; private set; }

        //public MemeVmo Meme { get; private set; }

        public int SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set => SetAndRaise(ref _selectedViewModelIndex, value);
        }

        //public override void Load(object parameter)
        //{
        //    SillyDudeLoader.Load(() => LoadSillyDude((int)parameter));
        //}

        //private async Task<SillyDudeVmo> LoadSillyDude(int id)
        //{
        //    var dude = await _dudeService.GetSilly(id);

        //    Quote = new QuoteVmo(
        //        dude.SourceUrl,
        //        dude.Description,
        //        new TapCommand(url => Device.OpenUri(new Uri((string)url))));
        //    Filmo = new FilmoVmo(dude.FilmoMarkdown);
        //    Meme = new MemeVmo(dude.MemeUrl);
        //    RaisePropertyChanged(nameof(Quote));
        //    RaisePropertyChanged(nameof(Filmo));
        //    RaisePropertyChanged(nameof(Meme));

        //    return new SillyDudeVmo(dude, null);
        //}
    }
}
