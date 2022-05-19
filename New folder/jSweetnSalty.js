
//instantiate variables
let sweets = 0;
let lineBreak = 0;
let saltys = 0;
let sns = 0;
let concatenation = '';

var numbs = [];

for(let i = 1; i <= 1000; i++)
{
    
    
    
    
    if(i % 3 == 0 && i % 5 == 0)//FIRST, check if divisible by both 3 AND 5
    {
        numbs.push("Sweet&Salty ");
        sns++;
    }

    //Then we can check if only one of them are true
    else if(i % 3 == 0)
    {
        numbs.push("Sweet ");
        sweets++;
    }
    else if(i % 5 == 0)
    {
        numbs.push("Salty ");
        saltys++;
    }

    //If not, we're just adding the number to the array
    else
    {
        numbs.push(i + " ");
    }

    //we check if 'i' is divisible by 20 AFTER the previous if statements because we're emptying a bunch of variables we want to use in the iteration and this if statement is using variables we need from this iteration
    if(i % 20 == 0)
    {
        //must now concat the array using a for loop
        for(let x = 0; x < numbs.length; x++)
        {
            concatenation += numbs[x];
        }
        numbs = [];//empty the numbs array for re-use
        console.log(concatenation);//print the concatenation
        concatenation = '';//empty the concatenation
    }
}


//print how many of each showed up
console.log(" ");
console.log("Sweets: " + sweets);
console.log("Saltys: " + saltys);
console.log("Sweet&Saltys: " + sns);
