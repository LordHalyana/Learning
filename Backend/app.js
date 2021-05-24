var express = require("express");
var app = express();


// "/" => "Hi there!"
app.get("/", function(req, res){
    res.send("Hi There!");
});

// "/bye" => "Goodbye!"
app.get("/bye", function(req, res){
    res.send("Goodbye!");
});

// "/dog" => "WOOOF!"
app.get("/dog", function(req, res){
    console.log("SOMEONE SENDT A REQUEST TO /DOG");
    res.send("WOOF!");
});

app.get("/cat", function(req, res){
    res.send("MEAOW!");
});

app.get("/r/:subredditName", function(req, res){
    var subreddit = req.params.subredditName;
    res.send("WELCOME TO THE "+  subreddit.toUpperCase() +" SUBREDDIT!");
});

app.get("/r/:subredditName/comments/:id/:title/", function(req, res){
    res.send("WELCOME TO A SUBREDDIT!");
});


app.get("*", function(req, res) {
    res.send("404! page not in Database");
});

// Tell Express to Listen for Requests (start Server)

app.listen(process.env.PORT, process.env.IP, function(){
    console.log("Server has started!");
});