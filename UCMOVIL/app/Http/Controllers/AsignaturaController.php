<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Asignatura;
use App\RamosActuale;

class AsignaturaController extends Controller
{
  public function index()
  {
      return view('DirectorIndex');   //se debe cambiar la vista
  }

  public function CodigoA(Request $request){
    $nombre = DB::table('version_ramos')->where('id_ramo', $request->id)->get();

    foreach ($nombre as $codigo) {
      $codigos = Asignatura::all()->where('id_asignatura', $codigo->id_asignatura)->first();
      echo $codigos->id_asignatura;
      return;
    }
    return;
  }

  public function NameA(Request $request){
    $nombre = DB::table('version_ramos')->where('id_ramo', $request->id)->get();

    foreach ($nombre as $codigo) {
      $codigos = Asignatura::all()->where('id_asignatura', $codigo->id_asignatura)->first();
      echo $codigos->nombre;
      return;
    }
  	return;
  }

  public function ProfesorA(Request $request){
  	$profesor = DB::table('version_ramos')->where('id_ramo', $request->id)->first();
	if($profesor != ""){
			foreach ($profesor as $a) {
			$a = DB::table('profesores')->where('id', $profesor->id_profesor)->first();
			echo $a->nombre;
			return;
		}
	}
	return ;
  }

  public function HorarioA(Request $request){
    $obtenerRamo = DB::table('version_ramos')->where('id_ramo', $request->id)->first();
  	$horarios["horario"] = DB::table('horarios')->where('id_asignatura', $obtenerRamo->id_asignatura)->get();
	
	return response()->json($horarios);
  }

  public function NotasA(Request $request){
    $obtenerRamos ['ramosactuale'] = RamosActuale::all()->where('id_alumno', $request->id);
  
    return response()->json($obtenerRamos);
  }

  public function NotasAsignatura(Request $request){
    $ObtenerNotas ['ramosactuale'] = RamosActuale::all()->where('id_alumno', $request->alumno)->where('id_ramo', $request->id);
  
    return response()->json($ObtenerNotas);
  }
}
