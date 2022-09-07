# Getting Started with 2shine for Oqtane

## Prerequisites

1. Install git from https://git-scm.com/downloads/ or use your favorite git client

2. Install node.js from https://nodejs.org/en/download/
   - we recommend using the current LTS release
   - we tested this skin with v16.15.1 and later, earlier version might work to

## Installation

1.  Create a folder for your project open the terminal and navigate to this folder.
2.  Clone the 2shine Oqt github repository by running:

        `git clone https://github.com/2sic/oqtane-theme-2shine-bs5.git`

3.  To use the theme you have to rename some variables and files. To rename everything at once you can just navigate to **oqt-theme-2shine-bs5/Client/** and run:
   
        `npm install` and then `npm run rename-project`

4.  Navigate to the **Client/build-theme.json** file:

    1. The **OqtaneRoot** setting determins where the theme is delivered to (Please change this to the path of your oqtane installation)
    2. You can also take a look at the other settings

5.  To build the project run:

        `npm run build`

6.  Log in and Navigate to **Theme Management** if **2shine Oqtane theme with Bootstrap 5** isn't listed you may need to restart the application.

## Apply the Theme to a Site or Page

Apply the theme to the whole site:

1. Navigate to **Site Settings**
2. Change the **Default Theme** setting to the layout you wan't to apply
3. Change the **Default Container** setting to the available container

Apply the theme to a single page:

1. Navigate to **Page Management**
2. Choose the page you want to apply a layout to and click on **Edit**
3. Under **Appearance** chage the **Theme** setting to the layout you want to apply
4. Change the **Default Container** setting to the 2shine container
