<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Middleware\Profesor;
use Auth;

class ProfesorController extends Controller
{
  public function __construct()
  {
      $this->middleware('auth');      //revision del usuario conectado
      $this->middleware('profesor');  //cortador de paso para usuarios distintos a profesor*/
  }


  public function index()
  {
      return view('DirectorIndex'); //se debe cambiar la vista
  }
}