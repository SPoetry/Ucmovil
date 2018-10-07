<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Middleware\Secretaria;
use Auth;
use App\Noticia;

class SecretariaController extends Controller
{
  /*public function __construct()
  {
      $this->middleware('auth');      //revision del usuario conectado
      $this->middleware('secretaria');  //cortador de paso para usuarios distintos a secretaria
  }*/


  public function index()
  {
      return view('SecretariaIndex'); //se debe cambiar la vista
  }

  public function mostrar_noticia()
  {
    $noticias["noticias"] = Noticia::all()->where("estado","Aprobada");

    return response()->json($noticias);
  }

  public function agregar_noticia(Request $request)
  {
    $noticia = new Noticia;
    $noticia->titulo=$request->titulo;
    $noticia->texto=$request->texto;
    $noticia->estado=$request->estado;
    $noticia->propietario=$request->propietario;
    $noticia->save();
    return "ok";

  }

  public function editar_noticia()
  {
    //
  }
}
