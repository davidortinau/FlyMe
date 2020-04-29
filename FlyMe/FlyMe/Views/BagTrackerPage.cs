using System;
using FlyMe.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Markup.GridRowsColumns;

namespace FlyMe.Views
{
public class BagTrackerPage : ContentPage
{
    Color BgClr = Color.FromHex("#FFFFFF");

    Style<Label> LabelStyle = new Style<Label>(
        (Label.TextColorProperty, Color.White)
    );
    private BagTrackerViewModel _vm;

    public BagTrackerPage() => Build();

    void Build()
    {
        BindingContext = _vm = new BagTrackerViewModel();

        Style<Frame> FrameStyle = new Style<Frame>(
            (Frame.HasShadowProperty, true),
            (Frame.BorderColorProperty, Color.FromHex("#333333"))
                
        );

        Style<Entry> EntryStyle = new Style<Entry>(
            (Entry.BackgroundColorProperty, Color.Transparent)
        );

        Resources = new ResourceDictionary();
        Resources.Add(LabelStyle);
        Resources.Add(FrameStyle);
        Resources.Add(EntryStyle);

        Title = "Track Your Bags";

        Content = new Grid()
        {
            RowDefinitions = Rows.Define(
                            (Row.Title, 44),
                            (Row.Content, Star),
                            (Row.Push, Star)
                        ),
            RowSpacing = 0,
            Padding = new Thickness(30),
            BackgroundColor = Color.White,
            Children = {
                new Label
                            {
                                Text = "Search by",
                                FontSize = 24,
                                TextColor = Color.FromHex("#333333")
                            }
                .Row(Row.Title),
                    
                                
                            new Frame
                            {
                                CornerRadius = 0,
                                Padding = 12,
                                Content = new StackLayout
                                {
                                    Spacing = 12,
                                    Children =
                                    {
                                        new Entry
                                        {
                                            Placeholder = "Bag Tag #"
                                        },
                                        new Entry
                                        {
                                            Placeholder = "File Reference #"
                                        },
                                        new Entry
                                        {
                                            Placeholder = "Last Name"
                                        },
                                        new Button
                                        {
                                            Text = "SEARCH",
                                            HeightRequest = 66,
                                            StyleClass = new string[] {"actionButton" },
                                            CornerRadius = 0,
                                            FontSize = 18
                                        }
                                        .Margins(top: 20)
                                        .Bind(nameof(_vm.SearchCommand))

                                    }
                                }
                            }.Row(Row.Content), // Frame
                            new Image
                            {
                                Source = new FontImageSource
                                {
                                    FontFamily = (OnPlatform<string>)Application.Current.Resources["FontAwesome"],
                                    Glyph = IconFont.Suitcase,
                                    Size = 88,
                                    Color = Color.LightGray
                                }
                            }
                            .Center()
                            .Row(Row.Push)
                            
                        
                }
        };
    } // Build

    enum Row { Title, Content, Push }
}
}
