<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Pedido extends Model
{
    protected $fillable = ['id_pedido','user_id','estado','tipo'];

    public function usuario()
    {
      return $this->belongsTo(User::class, 'user_id', 'id');
    }

    public function detalle_pedidos()
    {
      return $this->hasMany(DetallePedidos::class, 'pedido_id', 'id_pedido');
    }
}
