@extends('layout')

@section('title', "Usuario {$user->id_usuario}")

@section('content')
  <br><br><br>
  <div class="card" style="width: 13rem;">
    <img class="card-img-top" src="http://misimagenesde.com/wp-content/uploads/2017/05/foto-de-perfil-3.jpg" alt="Card image cap">
    <div class="card-body">
      <p class="card-text">
        <li>Id: {{$user->id_usuario}}</li>
        <li>Nombre: {{$user->nombre}}</li>
        <li>Dpto: {{$user->id_usuario}}</li>
      </p>
      <a href="#" class="btn btn-primary">Go somewhere</a>
    </div>
  </div>

@endsection
