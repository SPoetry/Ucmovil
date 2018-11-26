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
    $noticias	["noticias"] = DB::table('noticias')->where("estado","Aprobada")->get();

    return response()->json($noticias);
  }

  public function mostrar()
  {
    $noticias	["noticias"] = DB::table('noticias')->where("estado","Revision")->get();

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

  public function editar_noticia(Request $request)
  {
    $id_noticia = $request ->id_noticia;
    $titulo= $request ->titulo;
    $texto= $request ->texto;
    $estado= $request ->estado;
    $propietario= $request ->propietario;
    DB::table("noticias")->where('id_noticia',$id_noticia)->update([
      'titulo'=>$titulo,
      'texto'=>$texto,
      'estado'=>$estado,
      'propietario'=>$propietario
    ]);
    return "ok";
  }

  public function aceptar(Request $request)
{
  $id_noticia = $request ->id_noticia;
  $estado = $request ->estado;
  DB::table("noticias")->where('id_noticia',$id_noticia)->update([
    'estado'=> $estado
  ]);
  return "ok";
}

    public function rechazar(Request $request)
    {
      $id_noticia = $request ->id_noticia;
      $estado = $request ->estado;
      DB::table("noticias")->where('id_noticia',$id_noticia)->update([
        'estado'=> $estado
      ]);
      return "ok";
    }

    public function solicitudes(Request $request)
    {
      $solicitudes	["solicitudes"] = DB::table('solicitudes')->where("estado","Revision")->get();

      return response()->json($solicitudes);
    }

    public function rechazarsolicitud(Request $request)
    {
      $id = $request ->id;
      $estado = $request ->estado;
      DB::table("solicitudes")->where('id',$id)->update([
        'estado'=> $estado
      ]);
      return "ok";
    }

    public function aceptarsolicitud(Request $request)
    {
      $id = $request ->id;
      $estado = $request ->estado;
      DB::table("solicitudes")->where('id',$id)->update([
        'estado'=> $estado
      ]);
      return "ok";
    }



}
