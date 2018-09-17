@extends('layoutpedido')

@section('content')
    <ul>
      <br><br>
    <h1 class = "panel-title">{{auth()->user()->nombre}}</h1>
    <br><br>
    <table class="table">
    <thead class="thead-dark">
      <tr>
        <th scope="col">#</th>
        <th scope="col">Numero de pedido</th>
        <th scope="col">Departamento</th>
        <th scope="col">Tipo</th>
        <th scope="col">Fecha</th>
        <th scope="col">Estado</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      @forelse ($pedidos as $pedido)

      @if($pedido->estado == 0)
        <tr>
      @elseif ($pedido->estado==1)
        <tr bgcolor="#81F79F">
      @else
        <tr bgcolor="#FA5858">
      @endif

        <th scope="row">{{$loop->iteration}}</th>
        <td><a href="/pedido/{{$pedido->id_pedido}}">{{$pedido->id_pedido}}</a></td>
        <td>{{$pedido->usuario->nombre}}</td>

        @if($pedido->tipo)
          <td>Ingreso</td>
        @else
          <td>Retiro</td>
        @endif

        <td>Hoy</td>
        @if (auth()->user()->id==1)
          <td width="5%">
            <form action="/pedidos" method="post">
              {{ csrf_field() }}
              <input type="hidden" name="estatus" value="1">
              <input type="hidden" name="id_pedido" value={{$pedido->id_pedido}}>
              <input type=image src={{url('/images/Tick.png')}} width="25" height="25">
            </form>
          </td>
          <td width="5%">
            <form action="/pedidos" method="post">
              {{ csrf_field() }}
              <input type="hidden" name="estatus" value="2">
              <input type="hidden" name="id_pedido" value={{$pedido->id_pedido}}>
              <input type=image src={{url('/images/x.png')}} width="25" height="25">
            </form>
          </td>

        @else
          @if($pedido->estado == 0)
          <td><center><img src={{url('/images/wait.png')}} title="Pendiente" width="25" height="25"/></center></td>
          @elseif ($pedido->estado == 1)
          <td><img src={{url('/images/Tick.png')}} title="Aceptado" width="25" height="25"/></td>
          @else
          <td><img src={{url('/images/x.png')}} title="Rechazado" width="25" height="25"/></td>
          @endif
        @endif
        <td></td>
      </tr>
      @empty
        <li>No hay objetos en el inventario.</li>
      @endforelse
    </tbody>
    </table>

@endsection

@section('sidebar')
    @parent
@endsection
