# Panes in the 2shine Oqtane Theme

2shine uses the new convention in Oqtane 3.2 which defaults to the pane `Default`. 
If you're using it on an older Oqtane, you'll need to create an `Admin` pane as well.

## Pane: Default

This is the main pane for content. 

## Pane: Header

This is a special pane for header content.
By default, it's above the breadcrumb.
There is some magic added to ensure that it's basically gone when you don't have content, or that it's taller when it does.

## Add More Panes

We encourage you to not do this, as it will make content management more difficult. 
But if you need them anyhow (maybe a `Footer` pane), just

1. Add the name of it to the `ThemeBase.cs`
1. Add the pane itself to the `Default.razor`