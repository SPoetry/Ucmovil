<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Middleware\Profesor;
use App\VersionRamo;
use App\PonderacionesRamo;
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
	    $impartidos["impartidos"] =   VersionRamo::all()->where('id_profesor', $request->id);  //conexion a la base de datos y ordenados
      return response()->json($impartidos);  //entrega datos en forma de json
	  }

    public function mostrar_ponderaciones(Request $request)  //entrega todos los datos de las ponderaciones
    {
      $ponderaciones["ponderaciones"] = PonderacionesRamo::all()->where('id_ramo', $request->id);  //conexion a la base de datos y ordenados
      return response()->json($ponderaciones);  //entrega datos en forma de json
    }

    public function mostrar_lista(Request $request)  //entrega la lista de alumnos pertenecientes a un curso
    {
      $AlumnosArray = DB::table('ramos_actuales')->select('id_alumno')->where('id_ramo', $request->id)->distinct()->get();

      $alumnos["alumnos"] =   DB::table('alumnos')->select('id','nombre')->whereIn('id', $AlumnosArray->pluck('id_alumno'))->get();  //conexion a la base de datos y ordenados
      return response()->json($alumnos);  //entrega datos en forma de json
    }

    public function ingresar_ponderaciones(Request $request)  //entrega todos los datos de los ramos impartidos
    {
        for ($i=1; $i <=10 ; $i++) {
            if ($i == 1) {$P_nota = $request->P_nota1;}
            if ($i == 2) {$P_nota = $request->P_nota2;}
            if ($i == 3) {$P_nota = $request->P_nota3;}
            if ($i == 4) {$P_nota = $request->P_nota4;}
            if ($i == 5) {$P_nota = $request->P_nota5;}
            if ($i == 6) {$P_nota = $request->P_nota6;}
            if ($i == 7) {$P_nota = $request->P_nota7;}
            if ($i == 8) {$P_nota = $request->P_nota8;}
            if ($i == 9) {$P_nota = $request->P_nota9;}
            if ($i == 10) {$P_nota = $request->P_nota10;}

            DB::table("ponderaciones_ramos")->where(["id_ramo" => $request->id, "N_nota" => $i])->update(['P_nota' => $P_nota]);

        }
        return "Success";
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
