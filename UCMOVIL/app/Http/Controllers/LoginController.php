<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Auth;
use Illuminate\Support\Facades\Session;

class LoginController extends Controller
{
    public function Login(){
    	$credentials = $this->validate(request(),[
    		'email' => 'required|string',
    		'password'=>'required|string'
    		]);

    	if(Auth::attempt($credentials, true)){
            echo(Auth()->user()->id);
            echo(",");
            echo(Auth()->user()->tipo);
            return;
    	}
    	return "no";
    }
}
