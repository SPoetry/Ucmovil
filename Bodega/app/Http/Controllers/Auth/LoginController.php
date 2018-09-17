<?php

namespace App\Http\Controllers\Auth;

use Auth;
use App\Http\Controllers\Controller;

class LoginController extends Controller
{

  public function __construct(){
    $this->middleware('guest', ['only' => 'showlogin']);
  }

  public function showlogin(){
    return view('auth.login');
  }


  public function login(){

    $credentials = $this->validate(request(),[
      'id' => 'required|integer',
      'password' => 'required|string'
    ]);


    if(Auth::attempt($credentials, true))
    {
    return redirect()->route('inventario');
    }
    return back()->withErrors(['id' => 'Usuario o contraseña incorrectos']);
  }

  public function logout(){
    Auth::logout();
    return redirect('/')->with('msg', 'Sesión finalizada');;
  }
}
