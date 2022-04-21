read int1
read int2
if [[ $int1 != 0 && $int2 != 0 && $int1 -gt -100 && $int2 -lt 100 ]]
then
echo $((int1 + int2))
echo $((int1 - int2))
echo $((int1 * int2))
echo $((int1 / int2))
fi
