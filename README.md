# This is the repository for the exercises of Mosh Hamedani's C# Intermediate course

## Structure of the project
The current project is divided in two main folders:
1. <b>src</b>, which contains the classlibs for each module of the course (Classes, Inheritance, Interfaces and Polymorphism);
2. <b>tests</b>, which contains the tests for each implemented exercise

## Implementations

#### Stopwatch
It have four methods: `Start()`, `Stop()`, `CurrentDuration()` and `TotalDuration()`. The last two accepts a input parameter,
which is a value of the enum StopwatchDurationFormat, to indicate in what measure unit the data should be retrieved.

<i>CurrentDuration</i>: the duration of the current running stopwatch, the time elapse between a `Start()` call and a `Stop()` call.
<i>TotalDuration</i>: the sum of all time elapsed inside the current stopwatch.

To use it, simply instantiate and use the methods `Start()` and `Stop()` to measure the time.

```
var stopwatch = new Stopwatch();
stopwatch.Start();

// Do some operations

stopwatch.Stop();

stopwatch.CurrentDuration(); // Will retrieve the current duration of the Stopwatch in seconds.
```

#### StackOverflow Post
Simple class representing a StackOverflow Post.

It has two main methods: `UpVote()` and `DownVote()`. Each one sum or subtract a vote from the post.
To use it, just instantiate a new Post and begin to vote!

```
var stackOverflowPost = new Post("Lorem ipsum", "Lorem ipsum dolor sit amet");

stackOverflowPost.UpVote();
stackOverflowPost.UpVote();
stackOverflowPost.UpVote();

stackOverflowPost.DownVote();

// stackOverflowPost.Votes count should be 2!
```