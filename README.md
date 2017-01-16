# duality-companion
Duality Companion is a plugin for the Duality engine; it aims to contain utility classes, bits of code and extensions that, for one reason or another, cannot be included in the engine itself but are deemed to be useful, sought-after and trivial enough that they can made properly (at least, in a way that could satisfy the majority of users) once and for all, without the need to reinvent the wheel at each new project.

## how to contribute
There are a couple of basic rules that should be followed to ensure that this plugin does what it is set out to do:
* Ask yourself if the feature you want to add is something that is commonly requested: if yes, and it's not a complex feature, this is the right place.
* Try to keep the features as small as possible while maintaining their usefulness.
* Only add to the default behavior of Duality, don't change it.
* If possible, add xml comments to each class, method and property. At least give the methods, parameters and variables meaningful names.

The plugin itself should mimic the structure of the Duality engine, in terms of namespaces, as much as possible. Classes and extensions should be placed in the appropriate namespace according to their main use - or if there is a corresponding class in the vanilla engine.

## how to download
There are no downloads for now, the only way is to build from source.
Once the plugin has enough content, a binary will be made available.