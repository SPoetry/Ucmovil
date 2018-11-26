<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class DetallePedido extends Model
{
  protected $fillable = ['pedido_id','producto_id','cantidad'];

  public function pedido()
  {
    return $this->belongsTo(Pedido::class, 'pedido_id', 'id_pedido');
  }
  public function inventario()
  {
    return $this->belongsTo(Inventario::class, 'producto_id', 'id_producto');
  }
}
