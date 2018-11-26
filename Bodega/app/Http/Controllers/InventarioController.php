<?php


namespace App\Http\Controllers;


use App\Inventario;
use App\PedidoTemporal;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class InventarioController extends Controller
{
    public function __construct(){

      $this->middleware('auth');
    }

    public function show()
    {
      $inventario = Inventario::all();
      $pedidoTemporal = PedidoTemporal::all()->where('user_id', auth()->user()->id);
      return view('inventario.show', compact('pedidoTemporal', 'inventario'));
    }

    public function add()
    {
      $data= request()->all();

      if (DB::table('pedidos_temporales')->where([
        ['user_id', '=', auth()->user()->id],
        ['producto_id', '=', $data["id_prod"]],
        ])->first())
      {
        DB::table('pedidos_temporales')->where([
          ['user_id', '=', auth()->user()->id],
          ['producto_id', '=', $data["id_prod"]],
          ])->update(['cantidad' => max($data["cantidad"], 1)]);
      }else{
          DB::table('pedidos_temporales')->insert(['user_id'=> auth()->user()->id, 'producto_id' => $data["id_prod"], 'cantidad' => max($data["cantidad"], 1)]);
      }

      return redirect ('/inventario');
    }
}
