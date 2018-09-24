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
      $noticia = Noticia::all();
      return view('vistasecretaria',[
        'noticia' => $noticia -> toArray()
      ]); //se debe cambiar la vista
  }


  public function mostrar_noticia()
  {
      $noticia = Noticia::all();

      return view('Noticias',[
        'noticia' => $noticia -> toArray()
      ]);
  }

  public function agregar_noticia(Request $request)
  {
      $this->validate($request, [
        'texto'       => 'required',
        'estado'      => 'required',
        'propietario' => 'required',
        'titulo'      => 'required',
      ]);

      $noticia = new Noticia();
      $noticia->texto       = $request->texto;
      $noticia->estado      = $request->estado;
      $noticia->propietario = $request->propietario;
      $noticia->titulo      = $request->titulo;


      $noticia->save();
      return view('vistasecretaria');
  }






}
