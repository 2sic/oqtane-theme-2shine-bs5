# Folders and Namespaces

This is background information how Oqtane Themes work, and why the folders/files are treated in a special way.

## Background: Namespaces and Folders in Oqtane Themes

It's important to know that

1. Razor files in a folder automatically use that folder name as namespace, _unless_ it's specifically set.
1. The `ThemeInfo.cs` must be in the same namespace as the layout files
1. Containers must be in the same namespace or sub-namespaces as the layout files

> **Important**
> Oqtane will save the full namespace of selected **Themes** and **Containers** in the DB. 
> Because of this, renaming these razor-controls will always cause problems,
> so only change if really necessary and then re-check your site for issues. 

## Special Folder Layouts

The `Layouts` folder contains the layout Razor files, but they explicitly don't use the automatic namespace. 

Instead, the use the same namespace as the root, which is why the all have

```razor
@namespace ToSic.Oqt.Themes.ToShineBs5.Client
```

at the beginning. Once you've renamed your theme to your namespace, this will of course be different. 

## ThemeInfo.cs Namespace

The `ThemeInfo.cs` resides in the root folder and must have the same namespace as the layout files. 

Otherwise the layouts wouldn't be seen as belonging to this package and would be listed separately. 

## Special Folder Containers

This is a subfolder of the theme. The razor files will automatically receive sub-namespaces. 

But this is ok, because Oqtane will find them automatically as long as their namespace is deeper than the namespace of `ThemeInfo.cs`.