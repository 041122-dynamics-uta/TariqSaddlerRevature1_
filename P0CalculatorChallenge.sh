#!/bin/bash

chooseMath()
{
    
    mathTypes=("add" "subtract" "multiply" "divide") 

    if [ $validMath == 1 ]
    then
        validMath=0
        echo Please type which math you would like to perform by typing
        echo Add, subtract, multiply, or divide.
        read mathType
    else
        echo How about a valid input this time?
        echo Type one of the following:
        echo add, subtract, multiply, or divide.
        read mathType
    fi
    for((i=0; i<=3; i++))
    do
        echo ${mathTypes[i]}
        if [ ${mathTypes[i]} == $mathType ]
        then
            validMath=0
            inputNumbers
            break
        fi
    done
    if [ $validMath == 0 ]
    then
        chooseMath
    fi   
}





inputNumbers()
{
    echo I can $mathType two integers.
    echo Please input the first integer.
    read int1
    echo And the second integer.
    read int2

        if [ $mathType == "add" ] || [ $mathType == "+" ]
        then
            resultType="sum"
            add
        elif [ $mathType == "subtract" ] || [ $mathType == "-" ]
        then
            resultType="difference"
            subtract
        elif [ $mathType == "multiply" ] || [ $mathType == "*" ]
        then
            resultType="product"
            multiply
        elif [ $mathType == "divide" ] || [ $mathType == "/" ]
        then
            resultType="quotient"
            divide
        fi
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
        end
    fi
}

end()
{
    echo The $resultType of $int1 and $int2 is $result!
    echo Would you like to use the calculator again? Please type yes or no.
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
        echo Change the world. My final message. Goodbye.
        exit
    }
    else
        echo I\'m gonna assume you meant quit. Goodbye!
        exit
    fi
}


echo Welcome, user.
validMath=1
chooseMath
