# Documentation
--- 
## Navigation

You can either manage the navigation configurations with the parameters that you can give to the razor control ***NavEntry*** 
or you can give them to the ***navigation.json*** file, which is located in the src folder.

If you want the configurations from the config file to be used you just have to write the Key from the "NavConfigs" array which you want to use in the ***ConfigName*** parameter.
The parameters defined with the razor control have priority and will override anything defined in the config file. So if you want to use the config file it is best to only define the ConfigName
in the Blazor Component. 

---
### Those three parameters define the starting point for the navigation and you should only use one at a time the other two should just not be defined

1. ***StartingPage***
This parameter expects a string
You can either give a "*" to start from the root level or you can give a pageId to start from that specific page (Tip: To start with the children of a specific page put the pageId here and set the
***LevelSkip*** parameter to one)

2. ***StartLevel***
This parameter expects an int
This parameter expects a specific Level and will display anything on that level

3. ***PageList*** 
This parameter expects a List<int>
You can put pageId's in the list and the pages will be displayed 

---

1. ***ConfigName**:
This parameter expects a string
Makes the link between a certain control and the defined settings in the config file.


2. ***LevelDepth***:
This parameter expects an int
Is used to define how many levels the navigation should go down in the page tree from the defined starting point. 
The value 0 means that only the starting point will be displayed 1 means the children of the starting point will also be in the navigation.


3. ***LevelSkip (optional -> Default: 0)***
This parameter expects an int
Skips the defined number of levels if given 0 wont skip anything if given 1 skips one level

4. ***Display (optional -> Default: true)***
This parameter expects a boolean
Deactivates the generation of HTML for this navigation

5. ***Variation (optional -> Default: "Main")*** 
This parameter expects a string 
Choosing between the different layout options defined in ***Menu/NavEntry.razor***.