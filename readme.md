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

# Documentation

## Controls

### 1. Navigation:

You can either manage the navigation configurations with the parameters that you can give to the razor control **NavEntry** 
or you can give them to the **navigation.json** file, which is located in the src folder.

If you want the configurations from the config file to be used you just have to write the Key from the "NavConfigs" array which you want to use in the **ConfigName** parameter.
The parameters defined with the razor control have priority and will override anything defined in the config file. So if you want to use the config file it is best to only define the ConfigName
in the Blazor Component. 

**Those three parameters define the starting point for the navigation and you should only use one at a time the other two should just not be defined:**

1. **StartingPage:**  
This parameter expects a string.  
You can either give a "*" to start from the root level or you can give a pageId to start from that specific page (Tip: To start with the children of a specific page put the pageId here and set the **LevelSkip** parameter to 1).  

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
Choosing between the different layout options defined in ***Menu/NavEntry.razor***.

### 2. LanguageNav: 

The LanguageChanger control can be used to display Links to switch between different Languages change the names with are used to display these Links. This is done with the Languages Parameter.

1. **Languages:**   
This parameter expects a string.  
This parameter manages the display names of the languages. To change the display name of english which has the language code "en" you will need to write "en: *yourName*". To change the names of multiple languages you can write "en: *yourName*, nl-NL: *yourName*".

# History