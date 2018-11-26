@extends('layoutpedido')

@section('content')
    <ul>
      <br><br>
    <h1 class = "panel-title">Pedido numero: {{$id}}</h1>
    <br><br>
    <table class="table">
    <thead class="thead-dark">
      <tr>
        <th scope="col">#</th>
        <th scope="col">Imagen</th>
        <th scope="col">Id</th>
        <th scope="col">Nombre</th>
        <th scope="col">Cantidad</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      @forelse ($detalles as $producto)

        <tr>
        <th scope="row">{{$loop->iteration}}</th>
        <td><img src={{$producto->inventario->imagen}} width="40" height="40"/></td>
        <td>{{$producto->producto_id}}</td>
        <td>{{$producto->inventario->nombre}}</td>
        <td>{{$producto->cantidad}}</td>
      </tr>
      @empty
      @endforelse
    </tbody>
    </table>

@endsection

@section('sidebar')
    @parent
@endsection
