<?php

namespace App\Http\Controllers; 

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Middleware\Alumno;
use App\RamosActuale;
use Auth;

class AlumnoController extends Controller
{
	/*
  public function __construct()
  {
      $this->middleware('auth');      //revision del usuario conectado
      $this->middleware('alumno');    //cortador de paso para usuarios distintos a alumno
  }*/

  public function index()
  {
      return view('DirectorIndex');   //se debe cambiar la vista
  }

  public function RamosA(Request $request){
    $Anio = $request->anio;
    $RamosA["ramosactuale"] = DB::table('ramos_actuales')->select('id_ramo', 'id_alumno')->where('id_alumno', $request->id)->groupBy('id_alumno', 'id_ramo')->get();

    return response()->json($RamosA);
  }

  public function MensajeriaC(Request $request)
    {
      $ramosactuales = DB::table('ramos_actuales')->where('id_alumno', $request->id)->pluck('id_ramo');

      $ids= DB::table('version_ramos')->whereIn('id_ramo', $ramosactuales)->pluck('id_ramo');
      
      $RamosActuales = DB::table('version_ramos')->whereIn('id_ramo', $ids)->pluck('id_asignatura');

      $ramos["ramos"] = DB::table('asignaturas')->whereIn('id_asignatura', $RamosActuales)->get();

      return response()->json($ramos);
    }

    public function MensajesC(Request $request)
    {
      $MensajesChat["chat"] = DB::table('chat')->where('id_destinatario', $request->id_destinatario)->get();

      return response()->json($MensajesChat);
    }

    public function BuscarPorIdA(Request $request)
    {
      $Nombres = DB::table('alumnos')->where('id', $request->id)->get();

      foreach($Nombres as $nombre){
        echo $nombre->nombre;
      }
      return;
    }
}
