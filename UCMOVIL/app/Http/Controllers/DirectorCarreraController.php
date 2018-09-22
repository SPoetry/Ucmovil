<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Middleware\Director;
use Auth;

class DirectorCarreraController extends Controller
{
  public function __construct()
  {
      $this->middleware('auth');      //revision del usuario conectado
      $this->middleware('director');  //cortador de paso para usuarios distintos a director*/
  }


  public function index()
  {
      return view('DirectorIndex');
  }
}
