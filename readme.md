<img width="100%" src="https://github.com/2sic/dnn-theme-2shine-bs5/raw/main/images/logo-1000.png">

# Oqtane Skin/Theme with Bootstrap5

# Layouts

1. Default - Floating content on background, full-width sticky-header
2. Fullscreen - Modules can use the full width to set backgrounds
3. Centered - Content and Menu are max-width, background to right and left
4. Centered-Submenu - Paged/floating content with submenu to the left
5. Float-WideHeader - Paged/floating content with wide header

# WIP

1. Oqtane is still missing the DNN concept of each page having a specific language.
   That means the 2shine language classes and the page-root-neutral class are still missing.
   Those will be added as soon as Oqtane implments that feature.

# Prerequisites

1. Install git from https://git-scm.com/downloads/ or use your favorite git client

2. Install node.js from https://nodejs.org/en/download/
   - we recommend using the current LTS release
   - we tested this skin with v16.15.1 and later, earlier version might work to

# Installation

1.  Create a folder for your project open the terminal and navigate to this folder.

2.  Clone the 2shine Oqt github repository by running:

        git clone https://github.com/2sic/oqt-theme-2shine-bs5.git

3.  To use the theme you have to rename some variables and files. To rename everything at once you can just navigate to **oqt-theme-2shine-bs5/Client/** and run:
   
        npm install && npm run rename-project

4.  Navigate to the **Client/theme.jsonc** file:

    1. The **OqtaneRoot** setting determins where the theme is delivered to (Please change this to the path of your oqtane installation)
    2. You can also take a look at the other settings

5.  To build the project run:

        npm run build

6.  Log in and Navigate to **Theme Management** if **2shine Oqtane theme with Bootstrap 5** isn't listed you may need to restart the application

7.  Apply the theme to the whole site:

    1. Navigate to **Site Settings**
    2. Change the **Default Theme** setting to the layout you wan't to apply
    3. Change the **Default Container** setting to the available container

8.  Apply the theme to a single page:
    1. Navigate to **Page Management**
    2. Choose the page you want to apply a layout to and click on **Edit**
    3. Under **Appearance** chage the **Theme** setting to the layout you want to apply
    4. Change the **Default Container** setting to the 2shine container

# Documentation

## Build and deployment

There are some different node commands which help you to build and deploy the theme to oqtane:

      1. build          -> This will build the theme and deploy it to the designated location (in the theme.jsonc file)
      3. dotnet-watch   -> This will watch all of the .razor files and build and deploy the theme everytime it detects changes
      2. webpack-watch  -> This will run webpack and watch the .scss and .ts files for changes and build and deliver them

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
1. Oqtane will save the full namespace of selected **Themes** and **Containers** in the DB. 
Because of this, we highly recommend to always have a line like `@namespace ToSic.Oqt.Themes.ToShineBs5.Client.Layouts` at the beginning of these files,
so it doesn't change as you move files around.

---

# History

I hope u enjoy it ;-)