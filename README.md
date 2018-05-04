# Introduction
Included are 2 projects:
Config – Interface and non implemented concrete class for a configuration library.  Also includes a ConfigValue class and an IPersistSource interface.

ConfigTests – Start of framework for implementing a set of tests around Config.  An IPersistSource interface is included which can be expanded if needed, it represents saving to a flat file or to a Mongo database.

# Dependent Libraries
You will need or be using the following
VS2015 Community Edition

MSTest – not the best test framework but the default one that comes with VS.  Feel free to change it to xUnit or nUnit if you wish

Moq – Mocking framework, uses the Castle Dynamic Proxy interceptor which is also included.

Log4Net – file / console logging – configured to drop a file in the bin/Debug directory and also write to the console
 
# Exercises
Please complete the implementation of region “1. Basic operations” in IConfig / Config with appropriate tests

Please complete the implementation of region “2. User operations” in IConfig / Config with appropriate tests

Make sure to save down and submit 1) & 2) before starting on 3)

Take the code completed for 1) & 2).  
Please partially complete and refactor the interface and implementation for regions “3a. App operations” and “3b. App / User operations” – this last is where you can feel free to tear up the existing code and restructure the interfaces if you see fit.  
Note “partially complete” is fine, the point of 3) is to see what you come up with – don’t feel like you have to provided anything completely finished but the idea should be there.
 
# Other Libraries
There are many other libraries out there that do configuration that – see here.
 
# Disclaimer
Anything submitted as part of this exercise will be considered as having been provided to Future Wonder Co. without restrictions.
