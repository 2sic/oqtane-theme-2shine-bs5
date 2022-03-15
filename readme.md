<img width="100%" src="https://github.com/2sic/dnn-theme-2shine-bs5/raw/main/images/logo-1000.png">

# Oqtane Skin/Theme with Bootstrap5 

## Layouts

1. Default - Floating content on background, full-width sticky-header
2. Fullscreen - Modules can use the full width to set backgrounds
3. Centered - Content and Menu are max-width, background to right and left
4. Centered-Submenu - Paged/floating content with submenu to the left
5. Float-WideHeader - Paged/floating content with wide header

## WIP

1. Oqtane is still missing the DNN concept of each page having a specific language. 
That means the 2shine language classes and the page-root-neutral class are still missing. 
Those will be added as soon as Oqtane implments that feature.

## Documentation
### Controls
---
#### 1. Navigation Controls:
To achieve the most customizable Navigation we implemented a "NavEntry" control which can be given three Parameters.

##### ParentPage: 
This Parameter expects a Page object or the value "null". If the value is "null" the Navigation will start from the base Page Level and display anything that doesn't conflict with the other Parameters. The value can also be set to a Page object, if the value is a Page object the Navigation will start there and display anything that is a descendant from the specified Page and doesn't conflic with the other Parameters (To use a Page value you will either have to use a service like the IPageService or the PageState to e.g. always use the current page).

##### Levels: 
This Parameter expects an int value. If the value is set to one it will only display the pages that are one level below the "ParentPage" (so if the ParentPage is "null" only the root level and if the specified page is on level 3 only the 4th level). 

##### Variation: 
This Parameter expects a string. It can choose between the three available Layouts, Main (default), Mobile and Sidebar (This is Managed in the NavEntry.razor).

To implement all this we used a PageNavigator class which takes the given Parameters and creates PageNavigator classes for the pages which match the given criteria and also defines relations between the PageNavigators. The initial PageNavigator class is created with the PageNavigatorFactory class. 

#### 2. LanguageChanger Control: 

The LanguageChanger control can be used to display Links to switch between different Languages change the names with are used to display these Links. This is done with the Languages Parameter.

##### Languages: 
This Parameter expects a string and manages the display names of the languages. To change the display name of english which has the language code "en" you will need to write "en: yourName". To change the names of multiple languages you can write "en: yourName, nl-NL: yourName".

## History
