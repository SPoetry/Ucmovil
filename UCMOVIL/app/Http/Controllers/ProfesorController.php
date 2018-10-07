<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Middleware\Profesor;
use App\RamosImpartido;
use Auth;

class ProfesorController extends Controller
{
/*
  	public function __construct()
  	{
    	$this->middleware('auth');      //revision del usuario conectado
    	$this->middleware('profesor');  //cortador de paso para usuarios distintos a profesor
  	}*/

  	public function mostrar_impartidos(Request $request)  //entrega todos los datos de los ramos impartidos
  	{
	    $impartidos["impartidos"] =   RamosImpartido::all()->where('id_profesor', $request->id);  //conexion a la base de datos y ordenados
      return response()->json($impartidos);  //entrega datos en forma de json
	}

   	public function modificar_perfil(Request $request)
  	{
	    $perfil = new Profesore;   //se crea una estructura para ingresar los datos del profesor
	    $perfil->id_profesor = $request->id;
	    $perfil->ano_ingreso=$request->ano_ingreso; //se ingresan los datos de los request
	    $perfil->especialidad=$request->especialidad;
	    $perfil->nombre=$request->nombre;
	    $perfil->telefono=$request->telefono;
	    $perfil->save(); //se guarda en la base de datos todos los valores de la variable
	    return "ok";
  	}

 	public function index()
  	{
   		return view('DirectorIndex'); //se debe cambiar la vista
  	}
}
