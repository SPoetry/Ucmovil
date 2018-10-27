<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class AsignaturaController extends Controller
{
  public function index()
  {
      return view('DirectorIndex');   //se debe cambiar la vista
  }

  public function NameA(Request $request){
    $nombre = DB::table('asignaturas')->where('id_asignatura', $request->id)->get();

    foreach($nombre as $n){
        echo $n->nombre;
    }
  	return;
  }

  public function ProfesorA(Request $request){
  	$profesor = DB::table('ramos_impartidos')->where('id_asignatura', $request->id)->first();
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
  	$horarios["horario"] = DB::table('horarios')->where('id_asignatura', $request->id)->get();
	
	return response()->json($horarios);
  }
}
