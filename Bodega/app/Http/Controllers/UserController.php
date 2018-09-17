<?php

namespace App\Http\Controllers;

use App\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class UserController extends Controller
{
    public function index()
    {
      $users = User::all();
      $title='Lista de usuarios';
      return view('users.index', compact('users', 'title'));
    }

    public function show($id){
        $user = User::where('id_usuario',$id)->first();
        return view('users.show', compact('user'));
    }

    public function create(){
        return "Crear nuevo usuario";
    }
}
