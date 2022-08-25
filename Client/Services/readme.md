# Services in this theme

This folder contains services and helper classes etc.

It's to ensure that the razor files themselves have almost no logic in them.

This should help all who customize the theme to...

* better focus on what to change for visualization
* not get confused with technical things in the logic which is usually more complex
* better update their modified copy in future if we fix something in the logic

## Note about some inconsistencies

1. it also contains models, as we need a few, but ATM we don't want more folders in the root
1. It also contains some helpers which are not really services. We still have them here to keep things together