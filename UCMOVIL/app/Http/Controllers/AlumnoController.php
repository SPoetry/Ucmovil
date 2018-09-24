<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Middleware\Alumno;
use Auth;

class AlumnoController extends Controller
{
  public function __construct()
  {
      $this->middleware('auth');      //revision del usuario conectado
      $this->middleware('alumno');    //cortador de paso para usuarios distintos a alumno
  }

  public function index()
  {
      return view('DirectorIndex');   //se debe cambiar la vista
  }
}
