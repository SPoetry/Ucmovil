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
    public function saber_datos(Request $request){
        $id = $request->id;
        $tipo = $request->tipo;
        $usuario = DB::table($tipo)->where('id', $id)->get();
        foreach($usuario as $user)
            echo $user->especialidad. ",";
            echo $user->nombre. ",";
            echo $user->telefono. ",";
            return;
    }
}
