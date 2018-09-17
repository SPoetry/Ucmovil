<?php

namespace App\Http\Controllers;

use App\Pedido;
use App\PedidoTemporal;
use App\DetallePedido;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class PedidosController extends Controller
{
  function show (){
    if (auth()->user()->id == 1){
      $pedidos = Pedido::all();
      return view('Pedidos.show', compact('pedidos'));
    }else{
      $pedidos = Pedido::all()->where('user_id', auth()->user()->id);
      return view('Pedidos.show', compact('pedidos'));
    }
  }

  function change (){
    $data= request()->all();
    DB::table('pedidos')->where('id_pedido', $data["id_pedido"])->update(['estado' => $data["estatus"]]);
    return redirect ('/pedidos');

  }

  function detail($id){
    $detalles = DetallePedido::all()->where('pedido_id', $id);
    return view('Pedidos.detalle', compact('detalles', 'id'));

  }

  function enviar (){
    $user = auth()->user()->id;
    $tipo = 0;
    if($user>2){$tipo = 1;}
    $pedidos = PedidoTemporal::all()->where('user_id', $user);
    Pedido::create(['user_id'=> $user, 'tipo' => $tipo]);
    $id_pedido = Pedido::all()->last()->id_pedido;

    foreach ($pedidos as $pedido) {
      DetallePedido::create(['pedido_id' => $id_pedido, 'producto_id' => $pedido->producto_id, 'cantidad' => $pedido->cantidad]);
      DB::table('pedidos_temporales')->where([
        ['user_id', '=', $user],
        ['producto_id','=', $pedido->producto_id],
        ])->delete();
    }

    return redirect ('/inventario');

  }
}
