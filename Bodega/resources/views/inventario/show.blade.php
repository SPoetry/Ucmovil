@extends('layout')

@section('content')
    <ul>
      <br><br>
    <h1 class = "panel-title">{{auth()->user()->nombre}}</h1>
      <br><br>
      <div class="row mt-4">
        @forelse ($inventario as $producto)
          <div class="col" style="height:400px";>
            <div class="card" style="width: 14rem;">
              <img class="card-img-top" src="{{$producto->imagen}}" alt="Card image cap">
              <div class="card-body">
                <p class="card-text">
                  <li>Id: {{$producto->id_producto}}</li>
                  <li>Nombre: {{$producto->nombre}}</li>
                  <li>Stock: {{$producto->cantidad}}</li>
                  <div class="row">
                    <form action="/inventario" method="post">
                    {{ csrf_field() }}
                    <input type="hidden" name="id_prod" value={{$producto->id_producto}}>
                    <div class="col-xs-12 col-sm-4"><button type= "submit" class="btn btn-primary">Añadir</button></div>
                    <div class="col-xs-12 col-sm-2"></div>
                    <div class="col-xs-12 col-sm-6"><p><input type="number" class="form-control" id= "cantidad" name= "cantidad"></p></div>

                    </form>
                  </div>
                </div>
            </div>
          </div>
        @empty
            <li>No hay objetos en el inventario.</li>
        @endforelse
      </div>
    </ul>
    <br><br>

@endsection

@section('carrito')
  <br><br><br><br><br><br><br>
  @if(auth()->user()->id != 1)
      <div class="container" style="border-style:double">
        <div><center>Realizar Pedido:</center></div>
      <br>
          @forelse ($pedidoTemporal as $producto)
            <div class="col" style="height:300px";>
              <div class="card" style="width: 9rem;">
                <img class="card-img-top" src="{{$producto->producto->imagen}}" alt="Card image cap">
                <div class="card-body">
                  <p class="card-text">
                    <a>{{$producto->producto->nombre}}</a>
                    <li>{{$producto->cantidad}}/ {{$producto->producto->cantidad}}</li>
                    <div class="row">
                      <div class="col-xs-12 col-sm-4"><button type= "submit" class="btn btn-warning">Eliminar</button></div>
                    </div>
                  </div>
              </div>
            </div>
          @empty
            <li>Vacio</li>
          @endforelse
      <form action="/enviarPedido" method="post">
        {{ csrf_field() }}
        <div class="btn btn-primary btn-block"><button type= "submit" class="btn btn-primary">Enviar</button></div>
      </form>
      <br>
      </div>
  @endif
@endsection

@section('sidebar')
    @parent
@endsection
