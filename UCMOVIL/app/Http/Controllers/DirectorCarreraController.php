<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Http\Response;
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

  public function mostrar_asignatura(Request $request)  //entrega todos los datos de las asignaturas
  {
    $busqueda_malla = $request->id_malla;
    $asignaturas["asignatura"] = DB::table('asignaturas')
                                    ->join('mallas', 'asignaturas.id_malla','mallas.id_malla')
                                    ->select('asignaturas.*')
                                    ->where('asignaturas.id_malla',$busqueda_malla)
                                    ->orderBy('nombre')
                                    ->get();  //conexion a la base de datos y ordenados
    return response()->json($asignaturas);  //entrega datos en forma de objeto json
  }

  public function anadir_asignatura(Request $request)
  {
    $asignatura = new Asignatura;   //se crea una estructura para ingresar en Asignatura
    $asignatura->id_asignatura=$request->id_asignatura; //se ingresan los datos de los request
    $asignatura->nombre=$request->nombre;
    $asignatura->creditos=$request->creditos;
    $asignatura->prerequisito=$request->prerequisito;
    $asignatura->posicion_x=$request->posicion_x;
    $asignatura->posicion_y=$request->posicion_y;
    $asignatura->id_malla=$request->id_malla;
    $asignatura->save(); //se guarda en la base de datos todos los valores de la variable
    return "ok";
  }

  public function modificar_asignatura(Request $request)
  {
    $id_asignatura=$request->id_asignatura; //se ingresan los datos de los request
    $nombre=$request->nombre;
    $creditos=$request->creditos;
    $prerequisito=$request->prerequisito;
    if ($prerequisito == '' ){
      $prerequisito = null;
    }
    $posicion_x=$request->posicion_x;
    $posicion_y=$request->posicion_y;
    $id_malla=$request->id_malla;
    DB::table("asignaturas")->where('id_asignatura',$id_asignatura)->update([
          'nombre'=>$nombre,
          'creditos'=>$creditos,
          'prerequisito'=>$prerequisito,
          'posicion_x'=>$posicion_x,
          'posicion_y'=>$posicion_y,
          'id_malla'=>$id_malla
        ]);
    return "ok";
  }

  public function borrar_asignatura(Request $request)
  {
    $id_asignatura=$request->id_asignatura; //se ingresan los datos de los request
    DB::table("asignaturas")->where('id_asignatura',$id_asignatura)->delete();
    return "ok";
  }
}
