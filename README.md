# MakeCakeAsync
A simple .NET Core console app demonstrating asynchronous vs. synchronous code.  Related blog post: https://devblogs.microsoft.com/visualstudio/how-do-i-think-about-async-code/

## To run only the synchronous code:
- Uncomment the first two lines in the `Main` method
- Comment out the two `asyncCake` lines in the `Main` method
- Remove `async Task` from the `Main` method signature
