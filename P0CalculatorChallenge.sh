#!/bin/bash

chooseMath()
{
    
    mathTypes=("add" "subtract" "multiply" "divide") 

    if [ $validMath == 1 ]
    then
        validMath=0
        echo ------------------------------------------------------------
        echo Please type which math you would like to perform by typing
        echo add, subtract, multiply, or divide. Or to quit, type \'quit\'.
        echo ------------------------------------------------------------
        read mathType
    else
        echo --------------------------------------------------------------
        echo How about a valid input this time, $name?
        echo Type one of the following:
        echo add, subtract, multiply, or divide. Or to quit, type \'quit\'.
        echo --------------------------------------------------------------
        read mathType
    fi
    for((i=0; i<=${#mathTypes[@]}-1; i++))
    do
        # echo ${mathTypes[i]}
        if [ ${mathTypes[i]} == $mathType ]
        then
            validMath=0
            inputNumbers
            break
        elif [ $mathType == "quit" ]
        then
            echo --------------------
            echo Alright, seeya nerd.
            echo --------------------
            exit
        fi
    done
    if [ $validMath == 0 ]
    then
        chooseMath
    fi   
}





inputNumbers()
{
    echo ------------------------------
    echo I can $mathType two integers.
    echo Please input the first integer.
    echo ------------------------------
    read int1
    echo -----------------------
    echo And the second integer.
    echo -----------------------
    read int2

        if [ $mathType == "add" ]
        then
            resultType="sum"
            add
        elif [ $mathType == "subtract" ]
        then
            resultType="difference"
            subtract
        elif [ $mathType == "multiply" ]
        then
            resultType="product"
            multiply
        elif [ $mathType == "divide" ]
        then
            resultType="quotient"
            divide
        fi


        # switch [ mathType ]
        # case "add" : 
        # resultType="sum"
        # add
        # break;
}


add()
{
    result=$((int1 + int2))
    end
}
subtract()
{
    result=$((int1 - int2))
    end
}
multiply()
{
    result=$((int1 * int2))
    end
}
divide()
{
    if [ $int2 == 0 ]
    then
        echo DIVIDE BY 0 ERROR! Press enter to continue.
        read
        inputNumbers
        break
    else
        result=$((int1 / int2))
        remainder=$((int1 % int2))
        end
    fi
}

end()
{
    if [ $mathType == "divide" ]
    then
        echo -----------------------------------------------------------------------------
        echo The $resultType of $int1 and $int2 is $result with a remainder of $remainder!
    else
    echo -----------------------------------------------------------------------------
        echo The $resultType of $int1 and $int2 is $result!

    fi
    echo Would you like to use the calculator again? Please type yes or no.
    echo -----------------------------------------------------------------------------
    read ans

    if [ $ans == "yes" ]
    then
    {
        validMath=1
        chooseMath
    }
    elif [ $ans == "no" ]
    then
    {
        echo -------------------------------------
        echo Let\'s do this again sometime, $name!
        echo -------------------------------------
        exit
    }
    else
        echo ------------------------------------------
        echo I\'m gonna assume you meant quit. Goodbye!
        echo ------------------------------------------
        exit
    fi
}

echo -------------------------------
echo What is your name?
echo -------------------------------
read name
echo -------------------------------
echo Welcome to the Bash Calculator, $name!
validMath=1
chooseMath
