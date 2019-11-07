using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Shell), typeof(FlyMe.Droid.Renderers.MyShellRenderer))]
namespace FlyMe.Droid.Renderers
{
    public class MyShellRenderer : ShellRenderer
    {
        public MyShellRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementSet(Shell element)
        {
            base.OnElementSet(element);
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            var renderer = base.CreateShellItemRenderer(shellItem);

            //ViewCompat.SetElevation(renderer.Fragment.View, 0);

            return renderer;
        }

        protected override IShellToolbarTracker CreateTrackerForToolbar(Toolbar toolbar)
        {
            var tracker = base.CreateTrackerForToolbar(toolbar);
            var r = RendererFactory.GetRenderer(tracker.Page);
            ViewCompat.SetElevation(
                r.View, 0);
            
            return tracker;
        }

        protected override IShellFlyoutRenderer CreateShellFlyoutRenderer()
        {
            var flyout = base.CreateShellFlyoutRenderer();

            return flyout;
        }

        protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer()
        {
            var flyout = base.CreateShellFlyoutContentRenderer();


            var cl = ((CoordinatorLayout)flyout.AndroidView);

            var g = (AppBarLayout)cl.GetChildAt(0);
            g.SetBackgroundColor(Color.Transparent.ToAndroid());
            g.OutlineProvider = null;

            var header = g.GetChildAt(0);
            header.SetBackgroundColor(Color.Transparent.ToAndroid());

            return flyout;
        }

    }

    //public class MyShellToolbarTracker : ShellToolbarTracker
    //{
    //    Toolbar _toolbar;

    //    public MyShellToolbarTracker(IShellContext shellContext, Toolbar toolbar, DrawerLayout drawerLayout) : base(shellContext, toolbar, drawerLayout)
    //    {
    //        _toolbar = toolbar;
    //    }

    //    protected override void OnPageChanged(Page oldPage, Page newPage)
    //    {
    //        base.OnPageChanged(oldPage, newPage);

    //        UpdateNavBarHasShadow(_toolbar, newPage);
    //    }

    //    void UpdateNavBarHasShadow(Toolbar toolbar, Page page)
    //    {
    //        var parent = (AppBarLayout)toolbar.Parent;
    //        var appBarLayout = toolbar.Parent.GetParentOfType<AppBarLayout>();
    //        appBarLayout.SetElevation(0f);
            
    //    }

    //}
}