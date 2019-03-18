//Ejercicio 1
<br>
<?php
    $nombre="Juan";
    $apellido="Pérez";

    echo $apellido.", ".$nombre;
?>

<br>
//Ejercicio 2
<br>
<?php
    $x=-3;
    $y=15;

    print $x+$y;
?>

<br>
//Ejercicio 3
<br>
<?php
    $x=-3;
    $y=15;
    echo "</br>";

    echo $x."</br>";
    
    echo $y."</br>";
    
    echo $x+$y."</br>";
    
?>

<br>
//Ejercicio 4
<br>
<?php
    
    $contador=0;
    $suma=0;
    $acum=0;
    for($i=1;;$i++){

        for($j=2;;$j++){
            $contador++;
            $suma=$i+$j;
            if($acum<1000){

                $acum=$acum+$suma;
            }else{
                $acum=$acum-$suma;
                echo $acum."</br>";
                echo "Numeros sumados".$contador;
                $flag=1;
                break;
            }
            

        }

        if($flag==1){
            break;
        }    
        
    }
    
?>

<br>
//Ejercicio 7
<br>
<?php
$fecha= date("l j  F  Y");

echo $fecha."<br>";
echo date("e")."<br>";
echo date("l")." de ".date("j")."<br>";

switch(date("m")){
    case 01:
    case 02:
    case 03:
        echo "verano";break;
    case 04:
    case 05:
    case 06:
        echo "Otoño";break;
    case 07:
    case 08:
    case 09:
        echo "Invierno";break;
    default:
        echo "Primavera";
}
?>

<br>
//Ejercicio 9
<br>
<?php

    $vec=array();
    $suma=0;
    $promedio;
    
    for($i=1;$i<6;$i++){
        $vec[$i]=rand(0,10);
        $suma+=$vec[$i];
        echo "Nota ".$i.": ".$vec[$i]."<br>";
    }
    

    $promedio=$suma/sizeof($vec);

    if($promedio==6){
        echo "Igual a 6.."."Promedio: ".$promedio;
    }else if($promedio<6){
        echo "Menor a 6.."."Promedio: ".$promedio;
    }else{
        echo "Mayor a 6.."."Promedio: ".$promedio;
    }

?>

<br>
//Ejercicio10
<br>
<?php
$vec=array();
$contador=0;
    for($i=1;;$i++){

        if($i%2!=0){
            $vec[$contador]=$i;
            $contador++;
        }

        if($contador==10){
            break;
        }
    }
    echo "Muestro con For <br>";
    for($i=0;$i<=9;$i++){
        echo $vec[$i]."<br>";
    }

    echo "Muestro con ForEach <br>";
    foreach($vec as $valor){
        echo $valor."<br>";
    }

    echo "Muestro con While <br>";
    $contador=0;
    while($contador<sizeof($vec)){
        echo $vec[$contador]."<br>";
        $contador++;
    }


?>







