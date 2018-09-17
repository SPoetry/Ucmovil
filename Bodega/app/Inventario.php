<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Inventario extends Model
{
    protected $fillable = ['id_producto','nombre','imagen','cantidad'];

    public function detalle_pedidos()
    {
      return $this->hasMany(DetallePedidos::class, 'producto_id', 'id_producto');
    }
}
