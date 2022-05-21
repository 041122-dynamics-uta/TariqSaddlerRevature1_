
//Alec helped with this code

//"document" is the html document as an object
//getElementID() gets the id we decleare on a certain tag
//addEventListener() looks for a certain action from the user. In this case, it is the enter key
document.getElementById("firstnum").addEventListener("keypress", function(e){ //this eventlistener and function lets user press enter as an alternative to clicking submit
    if (e.key === "Enter")
    {
        e.preventDefault();
        document.getElementById("btn1").click();//If we press enter, it clicks the submit button, essentially
    }
})
document.getElementById("secondnum").addEventListener("keypress", function(e){ //this eventlistener and function lets user press enter as an alternative to clicking submit
    if (e.key === "Enter")
    {
        e.preventDefault();
        document.getElementById("btn2").click();
    }
})
document.getElementById("btn3").addEventListener("keypress", function(e){ //this eventlistener and function lets user press enter as an alternative to clicking submit
    if (e.key === "Enter")
    {
        e.preventDefault();
        document.getElementById("btn3").click();
    }
})

var input1, input2;

function buttonFunc()//this function is actually called in the html doc when the first submit button is pressed

{   
    
    let errmessage = []
    input1 = document.getElementById("firstnum").value;
    console.log(input1);
    if (input1 >= 0)
    {
    document.getElementById("err1").innerHTML = '';
    //firstinput1 = document.getElementById("firstnum");
    document.getElementById("secondPrompt").style.display = "block";//This will make the second button visible
    }
    else document.getElementsById("err1").append('Number cannot be negative');
    //errmessage.push("Number cannot be negative")
    //console.log(input1);

}

function buttonFunc2()
{
    input2 = document.getElementById("secondnum").value
    //console.log(input2-input1);
    if (input2 > input1 && input2-input1>200 && input2-input1<10000)
    {
        document.getElementById("err2").innerHTML = '';
        


    }
    else document.getElementById("err2").append('Your inputs must be at least 200 and no more than 10000 apart. Your second input must be greater than your first.')

}

// function startFunc()
// { //LEFT OFF: just need to add hide a things and color by class; then we can work on the function itself
//     //also working on the press enter to start function issue
//     console.log("success");

// }


//let firstnum = prompt("Please enter the beginning number of the range");






function startFunc(firstNum, finalNum)
{
    //Kinda combined the C# and Java versions of the SweetNSalty
    //instantiate variables
    let sweets = 0;
    let saltys = 0;
    let sns = 0;
    let lineBreak = 0;
    let concatenation = '';
    let range = finalNum - firstNum;

    let sum = 0;

    var numbs = [];
    for(let x = 0; x <= range; x++)
    {
        sum = parseInt(firstNum) + parseInt(x);//I have to parse ints because java insists on turning those numbers into strings
        numbs.push(sum);
        console.log(sum);
        //console.log("ITERATION");
    }

    for(let i = 0; i < numbs.length; i++)
    {
        
        if(numbs[i] % 3 == 0 && numbs[i] % 5 == 0)//FIRST, check if divisible by both 3 AND 5
        {
            //numbs.push("Sweet&Salty ");
            document.getElementById("results").append("Sweet&Salty ");
            
            sns++;
        }

        //Then we can check if only one of them are true
        else if(numbs[i] % 3 == 0)
        {
            //numbs.push("Sweet ");
            document.getElementById("results").append("Sweet ");
            sweets++;
        }
        else if(numbs[i] % 5 == 0)
        {
            //numbs.push("Salty ");
            document.getElementById("results").append("Salty ");
            saltys++;
        }

        //If not, we're just adding the number to the appended string
        else
        {
            //numbs.push(i + " ");
            document.getElementById("results").append(numbs[i] + " ");
        }


        //we don't need this block of code because we're not asking for any linebreaks here
        //we check if 'i' is divisible by 20 AFTER the previous if statements because we're emptying a bunch of variables we want to use in the iteration and this if statement is using variables we need from this iteration
        // if(lineBreak == 20)
        // {
        //     //must now concat the array using a for loop
        //     for(let x = 0; x < numbs.length; x++)
        //     {
        //         concatenation += numbs[x];
        //     }
        //     numbs = [];//empty the numbs array for re-use
        //     console.log(concatenation);//print the concatenation
        //     document.getElementById("results").append(concatenation);
        //     document.getElementById("results2").append("________________________");
        //     concatenation = '';//empty the concatenation
        //     lineBreak == 0;
        // }

        //lineBreak++;
    }


    
    console.log(" ");
    console.log("Sweets: " + sweets);
    console.log(" Saltys: " + saltys);
    console.log(" Sweet&Saltys: " + sns);

    //var values = [];

    //print how many of each showed up on the webpage
    document.getElementById("results2").append("Sweets: " + sweets);
    document.getElementById("results2").append("Saltys: " + saltys);
    document.getElementById("results2").append("SweetnSalty: " + sns);

    // values.push(sweets);
    // values.push(saltys);
    // values.push(sns);

    // return values;

    document.getElementById("resetButton").style.display = "block";

}

function resetPage()
{

    //ideally this erases the results, couldn't find a way in time
    document.getElementById("secondPrompt").reset();
    document.getElementById("firstPrompt").reset(); 
    //document.getElementById("results").r
    document.getElementById("results2").remove();
    document.getElementById("resetButton").reset(); 
    
}