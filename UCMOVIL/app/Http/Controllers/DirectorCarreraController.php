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
  public function __construct()
  {
      $this->middleware('auth');      //revision del usuario conectado
      $this->middleware('director');  //cortador de paso para usuarios distintos a director*/
  }
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

  public function anadir_asignatura()
  {

  }

  public function modificar_asignatura()
  {

  }

  public function borrar_asignatura()
  {

  }
}
