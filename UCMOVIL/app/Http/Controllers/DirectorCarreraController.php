<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Middleware\Director;

//Todos los modelos que se requeriran para controlar las funciones
use Auth; //Los valores de user estan en auth
use App\Asignatura;
use app\DirectoresCarrera;
use app\Malla;
use app\Profesore;
use app\RamosImpartido;

class DirectorCarreraController extends Controller
{
  /*public function __construct()
  {
      $this->middleware('auth');      //revision del usuario conectado
      $this->middleware('director');  //cortador de paso para usuarios distintos a director
  }*/
    /*
    ❖	Creación malla curricular
        ➢	Manejo malla nueva
        ➢	Manejo malla vieja
    ❖	Crud Perfil:
        ➢	Editar Correo
        ➢	Editar Apodo
        ➢	Editar Horario atención
    ❖	Crud asignación de profesores con asignaturas
    */
  public function index()
  {
      return view('DirectorIndex');
  }

  public function mostrar_asignatura()  //entrega todos los datos de las asignaturas
  {
    $asignaturas = DB::table('asignaturas')->orderBy('nombre')->get();  //conexion a la base de datos y ordenados
    //entrega datos en forma de json
    foreach ($asignaturas as $asignatura) {
      echo $asignatura->id_asignatura. ".";
      echo $asignatura->nombre. ".";
      echo $asignatura->creditos. ".";
      echo $asignatura->prerequisito.".";
      echo "/";
    }
    return ;
  }

  public function anadir_asignatura(Request $request)
  {
    $asignatura = new Asignatura;   //se crea una estructura para ingresar en Hotels
    $asignatura->id_asignatura=$request->id_asignatura; //se ingresan los datos de los request
    $asignatura->nombre=$request->nombre;
    $asignatura->creditos=$request->creditos;
    $asignatura->prerequisito=$request->prerequisito;
    $asignatura->save(); //se guarda en la base de datos todos los valores de la variable
    return "ok";
  }

  public function modificar_asignatura()
  {

  }

  public function borrar_asignatura()
  {

  }
}
