<img width="100%" src="https://raw.githubusercontent.com/2sic/oqt-theme-2shine-bs5/main/docs/assets/logo.svg">

# Oqtane Theme Template for Designers


> &nbsp;
>
> ## The only Oqtane Theme for passionate designers
>
> &nbsp;

This theme template is made especially for passionate designers who wish to create awesome looking solutions using Oqtane. 

## Magic for Designers

It has a bunch of magic baked into it, allowing for fast iterative design. 
Here's what makes it special:

1. Everything is Bootstrap 5 Best-Practices and most of the work is done with SASS, Webpack and Typescript
1. This means **95%** of all design work can be done _without_ recompiling the theme or restarting Oqtane
1. You can do all the work using VS Code (and without the heavy Visual Studio)
1. You can live-develop a theme and auto-deploy the builds to an Oqtane in your network - without restart
1. Almost all the logic is well hidden in a separate layer, staying out of your way. 

Why is this important?

1. Normal Oqtane Themes require you to recompile and restart Oqtane after every change.  
   This is very tiresome when you are tweaking the design step-by-step.  
1. Normal Oqtane Themes have a lot of logic and HTML mixed together the Razor files.  
   This makes it difficult and scary for designers. 
   It also makes it hard to update to an improved logic-stack without extensive manual work. 
1. Normal Oqtane Themes require a lot of code to get the Menus right.  
   This is error-prone and most designers will never get it right. 

## What's In the Package

1. A Bootstrap5 best practices setup with SASS, Typescript and Webpack, optimized to run in both Visual Studio as well as VS Code
1. Build-and-deploy automation
  * to rename everything when you start, since your Theme requires a unique namespace
  * to deploy to a local or remote Oqtane - both when building Bootstrap-only using Webpack, as well as when building the entire nuget package
1. Ca. 20 lightweight components containing only minimal HTML to create just about any design you want - usually without recompiling Razor
1. A menu engine allowing you to define what is shown in what menu, allowing designers to quickly modify visible menu structures in header, sidebar, footer, mobile etc.
1. MagicClasses (TODO:)
1. A configuration system which 
...

## Layouts

1. Default - Floating content on background, full-width sticky-header
2. Fullscreen - Modules can use the full width to set backgrounds
3. Centered - Content and Menu are max-width, background to right and left
4. Centered-Submenu - Paged/floating content with submenu to the left
5. Float-WideHeader - Paged/floating content with wide header

## Installation

👉🏾 See [Getting Started](./docs/gettings-started.md)

## Build and deployment

👉🏾 See [Build and Deploy](./docs/build-and-deploy.md)

## Configure a Theme and Styling in JSON

TODO:

## Get the Most out of Bootstrap5 with SASS

TODO:



# WIP

1. Oqtane is still missing the DNN concept of each page having a specific language.
   That means the 2shine language classes and the page-root-neutral class are still missing.
   Those will be added as soon as Oqtane implments that feature.


## Features 

### 1. Magic classes

There are numerous classes added to the different elements to determine some different stylings and they can be used for your own customizations.

1. **Body** 
   
   Here you can find a list (important:     check the **WIP** section above):
   https://2shine.org/page-classes

2. **Headerpane**

   A class will be added to the Headerpane if there aren't any modules populating it. That is used to style the Headerpane on different layouts. You can also use it to    make your own customizations.

## Controls

### 1. Navigation:

You can either manage the navigation configurations with the parameters that you can give to the razor control **NavEntry**
or you can give them to the **navigation.json** file, which is located in the src folder.

If you want the configurations from the config file to be used you just have to write the Key from the "NavConfigs" array which you want to use in the **ConfigName** parameter.
The parameters defined with the razor control have priority and will override anything defined in the config file. So if you want to use the config file it is best to only define the ConfigName
in the Blazor Component.

**These three parameters define the starting point for the navigation and you should only use one at a time the other two should just not be defined:**

1. **StartingPage:**  
   This parameter expects a string.  
   You can either give a "\*" to start from the root level or you can give a pageId to start from that specific page (Tip: To start with the children of a specific page put the pageId here and set the **LevelSkip** parameter to 1).

2. **StartLevel:**  
   This parameter expects an integer.  
   This parameter expects a specific Level and will display anything on that level

3. **PageList:**  
   This parameter expects a List if integers.  
   You can put pageId's in the list and the pages will be displayed

**These parameters are used to define more settings:**

1. **ConfigName:**
   This parameter expects a string.  
   Makes the link between a certain control and the defined settings in the config file.

2. **LevelDepth:**  
   This parameter expects an integer.  
   Is used to define how many levels the navigation should go down in the page tree from the defined starting point.
   The value 0 means that only the starting point will be displayed 1 means the children of the starting point will also be in the navigation.

3. **LevelSkip (optional):**  
   This parameter expects an integer (Default: 0).  
   Skips the defined number of levels if given 0 wont skip anything if given 1 skips one level

4. **Display (optional):**  
   This parameter expects a boolean (Default: true).  
   Deactivates the generation of HTML for this navigation

5. **Variation (optional):**  
   This parameter expects a string (Default: "Main").  
   Choosing between the different layout options defined in **_Menu/NavEntry.razor_**.

### 2. LanguageNav:

The LanguageChanger control can be used to display Links to switch between different Languages change the names with are used to display these Links. This is done with the Languages Parameter.

1. **Languages:**  
   This parameter expects a string.  
   This parameter manages the display names of the languages. To change the display name of english which has the language code "en" you will need to write "en: _yourName_". To change the names of multiple languages you can write "en: _yourName_, nl-NL: _yourName_".

## General Recommendations & Coding Style

1. Many of our controls have an obvious name like `Menu` but it can be confused with the `Oqtane.Theme.Controls.Menu`.
Since we rarely use the default Oqtane controls, we don't recommend having it in your `_imports.razor` but instead we reference them explicitly where we need them. 
<!-- 1. Oqtane will save the full namespace of selected **Themes** and **Containers** in the DB. 
Because of this, we highly recommend to always have a line like `@namespace ToSic.Oqt.Themes.ToShineBs5.Client.Layouts` at the beginning of these files,
so it doesn't change as you move files around. -->

See also [folder and namespace docs](./docs/folders-and-namespaces.md)

## Todo 2dm/2md

1. Must verify packaging etc. works
1. Reconsider including the dist-folder, and maybe renaming it to wwwroot???
1. Resources / multi-language of various parts

## Todo 2dm/2tl

1. Breadcrumb revealer doesn't work as expected, only hides "Home"
1. Styling of footer menu to be "something | something | something"
1. Nav features
  1. ability to exclude pages (especially on home level)
  2. verify that we need `toshine-mainnav-variations-...` classes
1. In general, probably rename `to-shine-...` classes to `toshine-...`
1. update bootstrap to 5.2

### Lower Priority

1. ideally try to move out the js for the page to the project Cre8ive
1. find a way to allow layouts/designs/logos etc. to vary by site-id
1. more configurable settings on layout, like breadcrumb on/off etc.

---

# History

1. Version 1.0.0 created ca. July 2022 but still WIP
1. Version 2.0.0 with major updates (docs not in sync yet) August 2022

---

I hope u enjoy it ;-)