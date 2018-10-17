<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Auth;
use Illuminate\Support\Facades\Session;
use App\User;

class LoginController extends Controller
{
    public function Login(){
    	$credentials = $this->validate(request(),[
    		'email' => 'required|string',
    		'password'=>'required|string'
    		]);

    	if(Auth::attempt($credentials, true)){

            $Usuarios["usuarios"] =   User::all()->where('email', Auth()->user()->email);
            //conexion a la base de datos y ordenados
            return response()->json($Usuarios);//entrega datos en forma de objeto json
    	}
    	return "no";
    }
}
