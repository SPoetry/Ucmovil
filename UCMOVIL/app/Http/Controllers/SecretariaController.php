<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Middleware\Secretaria;
use Auth;

class SecretariaController extends Controller
{
  public function __construct()
  {
      $this->middleware('auth');      //revision del usuario conectado
      $this->middleware('secretaria');  //cortador de paso para usuarios distintos a secretaria*/
  }


  public function index()
  {
      return view('SecretariaIndex'); //se debe cambiar la vista
  }

  public function mostrar_noticia()
  {
    $noticia = DB::table('noticias')->orderBy('id_noticia')->get();
    return $noticia;
  }

  public function agregar_noticia(Request $request)
  {
    $noticia = new Noticia;
    $noticia ->titulo = $request->titulo;
    $noticia ->texto = $request->titulo;
    $noticia ->estado = $request->titulo;
    $noticia ->propietario = $request->titulo;
    $noticia->save();
    return "ok";

  }

  public function editar_noticia()
  {
    //
  }
}
