# What's Inside the 2shine for Oqtane Package

## Overview

1. A Bootstrap5 best practices setup
1. Build-and-deploy automation
1. Ca. 20 lightweight Razor components
1. 5 already prepared Layouts (full-width, centered, etc.)
1. MagicMenu Engine 
1. MagicClasses (TODO:)
1. MagicSettings
1. MagicLanguages
1. ...

## Bootstrap5 Best Practices Setup

This is a Bootstrap5 best practices setup using

* SASS
* Typescript
* Webpack

It's optimized to run in both Visual Studio as well as VS Code

## Build and Deploy Automation

### Rename When Starting

Every Oqtane Theme must be created / compiled using a unique namespace. 
This is something like `MyCompany.Oqt.Themes.MyCustomer.Client`.
To start, you'll need to rename/replace the template names everywhere in the project. 
This is fully automated using `npm run rename-project`.

### Full Build with Automatic Deployment

TODO:
...nuget
...etc.

### Live Build with Webpack-Watch and Automatic Deployment

Designers work iteratively in many small steps.
This means a lot of small changes and a lot of reloading the page. 
Since **95%** of all work is done in SASS, 
we've created a npm/webpack configuration which will 
take `-watch` all your changes, automatically build and copy to the Oqtane you're working on. 

This works both for Oqtane installations on your PC as well as Oqtane servers in your network. 

## Lightweight Razor Components

TODO: 
containing only minimal HTML to create just about any design you want - usually without recompiling Razor

## Layouts

1. Default - Floating content on background, full-width sticky-header
2. Fullscreen - Modules can use the full width to set backgrounds
3. Centered - Content and Menu are max-width, background to right and left
4. Centered-Submenu - Paged/floating content with submenu to the left
5. Float-WideHeader - Paged/floating content with wide header

## MagicMenu Engine

TODO: 
allowing you to define what is shown in what menu, allowing designers to quickly modify visible menu structures in header, sidebar, footer, mobile etc.

## MagicClasses

Todo: 

## MagicSettings

TODO: 
 -A configuration system which 