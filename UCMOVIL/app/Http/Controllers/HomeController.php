<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Middleware\Director;
use Auth;

class HomeController extends Controller
{
    /**
     * Create a new controller instance.
     *
     * @return void
     */
    /*public function __construct()
    {
        $this->middleware('auth');
        $this->middleware('director');
    }*/

    /**
     * Show the application dashboard.
     *
     * @return \Illuminate\Http\Response
     */
    
    public function index()
    {
        return view('home');
    }
    public function Datos_a(Request $request){
        $id = $request->id;
        $tipo = $request->tipo;
        $usuario = DB::table($tipo)->where('id', $id)->get();
        foreach($usuario as $user){
            echo $user->nombre. ",";
            echo $user->telefono. ",";
            echo $user->ano_nacimiento. ",";
            echo $user->direccion. ",";
            echo $user->ano_ingreso. ",";
            echo $user->apodo. ",";
        }
        return;
    }

    public function Datos_s(Request $request){
        $id = $request->id;
        $tipo = $request->tipo;
        $usuario = DB::table($tipo)->where('id', $id)->get();
        foreach($usuario as $user){
            echo $user->nombre. ",";
            echo $user->telefono. ",";
            echo $user->apodo. ",";
        }
        return;
    }

    public function Datos_d(Request $request){
        $id = $request->id;
        $tipo = $request->tipo;
        $usuario = DB::table($tipo)->where('id', $id)->get();
        foreach($usuario as $user){
            echo $user->especialidad. ",";
            echo $user->nombre. ",";
            echo $user->telefono. ",";
            echo $user->apodo. ",";
        }
        return;
    }

    public function datos_p(Request $request){
        $id = $request->id;
        $tipo = $request->tipo;
        $usuario = DB::table($tipo)->where('id', $id)->get();
        foreach($usuario as $user){
            echo $user->especialidad. ",";
            echo $user->nombre. ",";
            echo $user->telefono. ",";
            echo $user->apodo. ",";
        }
        return;
    }

    public function CambioC(Request $request){
        $id = $request->id;
        $password = $request->password;
        $tipo = $request->tipo;
        DB::table('users')->where('id', $id)->update([
            'password'=>bcrypt($password)
          ]);
        return "ok";
    }

    public function CambioA(Request $request){
        $id = $request->id;
        $apodo = $request->apodo;
        $tipo = $request->tipo;
        DB::table($tipo)->where('id', $id)->update([
            'apodo'=>$apodo
          ]);
        return "ok";
    }

    public function CambioE(Request $request){
        $id = $request->id;
        $email = $request->email;
        $tipo = $request->tipo;
        DB::table('users')->where('id', $id)->update([
            'email'=>$email
          ]);
        return "ok";
    }
}
